import 'package:flutter/material.dart';
import 'package:logging/logging.dart';
import 'package:simply_lifestyle_app/data/repositories/products_repository.dart';
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
  final _log = Logger('HomeViewModel');

  List<Product> _products = [];
  List<Product> get products => _products;

  Future<Result> _load() async {
    try {
      final result = await _productsRepository.getProducts();
      switch (result) {
        case Ok<List<Product>>():
          _products = result.value;
          _log.fine('Loaded bookings');
        case Error<List<Product>>():
          _log.warning('Failed to load products', result.error);
      }

      return result;
    } finally {
      notifyListeners();
    }
  }
}