import 'package:flutter/material.dart';
import 'package:logging/logging.dart';
import 'package:simply_lifestyle_app/data/repositories/products/products_repository.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/utils/command.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class NewOrderViewModel extends ChangeNotifier {
  NewOrderViewModel({
    required ProductsRepository productsRepository,
  }) : _productsRepository = productsRepository {
    load = Command0(_load)..execute();
  }

  final ProductsRepository _productsRepository;

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
      final order = Order(
        customerId: values['customerId'],
        orderDate: DateTime.now(),
        orderStatus: OrderStatus.pending,
        orderItems: (values['orderItems'] as List<dynamic>)
            .map((item) => OrderItem(
                  productId: item['productId'],
                  quantity: item['quantity'],
                ))
            .toList(),
      );
      return await _ordersRepository.createOrder(order);
    } on Exception catch (e) {
      return Result.error(e);
    }
  }
}
