import 'package:simply_lifestyle_app/data/repositories/orders/orders_repository.dart';
import 'package:simply_lifestyle_app/data/services/api/api_client.dart';
import 'package:simply_lifestyle_app/domain/models/order/order.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class OrdersRepositoryRemote implements OrdersRepository{
  OrdersRepositoryRemote({
    required ApiClient apiClient,
  }) : _apiClient = apiClient;

  final ApiClient _apiClient;

  List<Order>? _cachedData;

  @override
  Future<Result<List<Order>>> getOrders() async {
    if (_cachedData == null) {
      // No cached data, request continents
      final result = await _apiClient.getOrders();
      if (result is Ok<List<Order>>) {
        // Store value if result Ok
        _cachedData = result.value;
      }
      return result;
    } else {
      // Return cached data if available
      return Result.ok(_cachedData!);
    }
  }

}