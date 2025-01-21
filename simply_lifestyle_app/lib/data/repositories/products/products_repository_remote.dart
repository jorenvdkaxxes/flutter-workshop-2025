import 'package:simply_lifestyle_app/data/repositories/products/products_repository.dart';
import 'package:simply_lifestyle_app/data/services/api/api_client.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class ProductsRepositoryRemote implements ProductsRepository {
  ProductsRepositoryRemote({
    required ApiClient apiClient,
  }) : _apiClient = apiClient;

  final ApiClient _apiClient;

  List<Product>? _cachedData;

  @override
  Future<Result<List<Product>>> getProducts() async {
    if (_cachedData == null) {
      // No cached data, request continents
      final result = await _apiClient.getProducts();
      if (result is Ok<List<Product>>) {
        // Store value if result Ok
        _cachedData = result.value;
      }
      return result;
    } else {
      // Return cached data if available
      return Result.ok(_cachedData!);
    }
  }
  
  @override
  Future<Result<Product>> getProductById(String id) {
    // TODO: implement getProductById
    throw UnimplementedError();
  }
}
