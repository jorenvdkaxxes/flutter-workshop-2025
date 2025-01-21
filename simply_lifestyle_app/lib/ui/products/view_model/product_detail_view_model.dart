import 'package:flutter/material.dart';
import 'package:logging/logging.dart';
import 'package:simply_lifestyle_app/data/repositories/products/products_repository.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/utils/command.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class ProductDetailViewModel extends ChangeNotifier {
  ProductDetailViewModel({
    required ProductsRepository productsRepository,
  }) : _productsRepository = productsRepository {
    loadProduct = Command1(_getProductById);
  }

  final ProductsRepository _productsRepository;

  late final Command1<void, String> loadProduct;

  final _log = Logger('ProductDetailViewModel');

  Product? _product;
  Product? get product => _product;

  Future<Result<void>> _getProductById(String id) async {
    try {
      final result = await _productsRepository.getProductById(id);
      switch (result) {
        case Ok<Product>():
          _product = result.value;
          _log.fine('Loaded product');
        case Error<Product>():
          _log.warning('Failed to load product', result.error);
      }

      return result;
    } finally {
      notifyListeners();
    }
  }
}
