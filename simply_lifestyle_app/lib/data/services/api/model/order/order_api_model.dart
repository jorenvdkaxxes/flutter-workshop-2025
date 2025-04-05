import 'package:simply_lifestyle_app/data/services/api/model/order/order_item_api_model.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_status.dart';

class OrderApiModel {
  OrderApiModel(
      {this.id,
      required this.customerId,
      required this.orderDate,
      required this.deliveryDate,
      required this.status,
      required this.orderItems});

  final String? id;
  final String customerId;
  final DateTime orderDate;
  final DateTime deliveryDate;
  final OrderStatus status;
  final List<OrderItemApiModel> orderItems;

  factory OrderApiModel.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'id': String id,
        'customerId': String customerId,
        'orderDate': String orderDate,
        'deliveryDate': String deliveryDate,
        'status': int status,
        'orderItems': List<dynamic> orderItems
      } =>
        OrderApiModel(
            id: id,
            customerId: customerId,
            orderDate: DateTime.parse(orderDate),
            deliveryDate: DateTime.parse(deliveryDate),
            status: OrderStatus.values[status],
            orderItems:
                orderItems.map((o) => OrderItemApiModel.fromJson(o)).toList()),
      _ => throw const FormatException('Failed to load order.'),
    };
  }
}
