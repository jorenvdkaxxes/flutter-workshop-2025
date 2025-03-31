import 'package:flutter/material.dart';
import 'package:logging/logging.dart';
import 'package:simply_lifestyle_app/data/repositories/orders/orders_repository.dart';
import 'package:simply_lifestyle_app/data/repositories/products/products_repository.dart';
import 'package:simply_lifestyle_app/domain/models/order/order.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_item.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_status.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/utils/command.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class NewOrderViewModel extends ChangeNotifier {
  NewOrderViewModel({
    required ProductsRepository productsRepository,
    required OrdersRepository ordersRepository,
  })  : _productsRepository = productsRepository,
        _ordersRepository = ordersRepository {
    load = Command0(_load)..execute();
  }

  final ProductsRepository _productsRepository;
  final OrdersRepository _ordersRepository;

  late Command0 load;
  final _log = Logger('NewOrderViewModel');

  List<Product> _products = [];
  List<Product> get products => _products;

  Future<Result> _load() async {
    try {
      final result = await _productsRepository.getProducts();
      switch (result) {
        case Ok<List<Product>>():
          _products = result.value;
          _log.fine('Loaded products');
        case Error<List<Product>>():
          _log.warning('Failed to load products', result.error);
      }

      return result;
    } finally {
      notifyListeners();
    }
  }

  Future<Result<void>> createOrder(Map<String, dynamic> values) async {
    try {
      final totalOrderItems = int.parse(values['orderItems'].toString());
      final orderItems = List<OrderItem>.empty(growable: true);
      for (var i = 1; i < totalOrderItems; i++) {
        final orderItemId = (values['orderItem_$i'] as Product).id!;
        final orderItemQuantity = int.parse(values['orderItemQuantity_$i']);
        final orderItem =
            OrderItem(productId: orderItemId, quantity: orderItemQuantity);
        orderItems.add(orderItem);
      }

      final order = Order(
        customerName: values['customerName'],
        orderDate: DateTime.now(),
        deliveryDate: values['deliveryDate'],
        status: OrderStatus.pending,
        orderItems: orderItems,
      );
      return await _ordersRepository.createOrder(order);
    } on Exception catch (e) {
      return Result.error(e);
    }
  }
}
