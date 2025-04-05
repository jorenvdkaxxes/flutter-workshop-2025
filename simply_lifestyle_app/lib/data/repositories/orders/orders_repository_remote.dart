import 'package:simply_lifestyle_app/data/repositories/orders/orders_repository.dart';
import 'package:simply_lifestyle_app/data/services/api/api_client.dart';
import 'package:simply_lifestyle_app/data/services/api/model/order/order_api_model.dart';
import 'package:simply_lifestyle_app/data/services/api/model/order/order_item_api_model.dart';
import 'package:simply_lifestyle_app/data/services/api/model/order/order_post_api_model.dart';
import 'package:simply_lifestyle_app/domain/models/order/order.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_item.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class OrdersRepositoryRemote implements OrdersRepository {
  OrdersRepositoryRemote({
    required ApiClient apiClient,
  }) : _apiClient = apiClient;

  final ApiClient _apiClient;

  @override
  Future<Result<List<Order>>> getOrders() async {
    try {
      final result = await _apiClient.getOrders();
      switch (result) {
        case Ok<List<OrderApiModel>>():
          final parsedResult = result.value
              .map((o) => Order(
                  id: o.id!,
                  customerId: o.customerId,
                  orderDate: o.orderDate,
                  deliveryDate: o.deliveryDate,
                  status: o.status,
                  orderItems: o.orderItems
                      .map((oi) => OrderItem(
                          id: oi.id!,
                          productId: oi.productId,
                          quantity: oi.quantity))
                      .toList()))
              .toList();

          return Result.ok(parsedResult);
        case Error<List<OrderApiModel>>():
          return Result.error(result.error);
      }
    } on Exception catch (e) {
      return Result.error(e);
    }
  }

  @override
  Future<Result<void>> createOrder(Order order) async {
    try {
      final orderPostApiModel = OrderPostApiModel(
          customerFirstName: order.customerFirstName!,
          customerLastName: order.customerLastName!,
          deliveryDate: order.deliveryDate,
          status: order.status,
          orderItems: order.orderItems
              .map((o) => OrderItemApiModel(
                  productId: o.productId, quantity: o.quantity))
              .toList());
      return _apiClient.postOrder(orderPostApiModel);
    } on Exception catch (e) {
      return Result.error(e);
    }
  }
}
