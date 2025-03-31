import 'package:simply_lifestyle_app/domain/models/order/order.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

abstract class OrdersRepository {
  /// Returns the list of [Order].
  Future<Result<List<Order>>> getOrders();

  /// Create an order
  Future<Result<void>> createOrder(Order order);
}