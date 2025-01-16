import 'dart:async';

import 'package:simply_lifestyle_app/data/repositories/products/products_repository.dart';
import 'package:simply_lifestyle_app/data/services/local/local_data_service.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class ProductsRepositoryLocal implements ProductsRepository {
  ProductsRepositoryLocal({
    required LocalDataService localDataService,
  }) : _localDataService = localDataService;

  final LocalDataService _localDataService;

  @override
  Future<Result<List<Product>>> getProducts() async {
    final products = _localDataService.getProducts();

    return Result.ok(products);
  }
}
