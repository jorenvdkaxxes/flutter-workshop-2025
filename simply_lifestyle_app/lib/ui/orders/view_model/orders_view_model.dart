import 'package:flutter/material.dart';
import 'package:logging/logging.dart';
import 'package:simply_lifestyle_app/data/repositories/orders/orders_repository.dart';
import 'package:simply_lifestyle_app/domain/models/order/order.dart';
import 'package:simply_lifestyle_app/utils/command.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class OrdersViewModel extends ChangeNotifier {
  OrdersViewModel({
    required OrdersRepository ordersRepository,
  }) : _ordersRepository = ordersRepository {
    load = Command0(_load)..execute();
  }

  final OrdersRepository _ordersRepository;

  late Command0 load;
  final _log = Logger('OrdersViewModel');

  List<Order> _orders = [];
  List<Order> get orders => _orders;

  Future<Result> _load() async {
    try {
      final result = await _ordersRepository.getOrders();
      switch (result) {
        case Ok<List<Order>>():
          _orders = result.value;
          _log.fine('Loaded orders');
        case Error<List<Order>>():
          _log.warning('Failed to load orders', result.error);
      }

      return result;
    } finally {
      notifyListeners();
    }
  }
}