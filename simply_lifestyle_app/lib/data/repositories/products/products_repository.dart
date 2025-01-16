import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

abstract class ProductsRepository {
  /// Returns the list of [Product].
  Future<Result<List<Product>>> getProducts();
}