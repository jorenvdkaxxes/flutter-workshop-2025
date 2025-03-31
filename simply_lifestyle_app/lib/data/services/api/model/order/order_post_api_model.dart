import 'package:simply_lifestyle_app/data/services/api/model/order/order_item_api_model.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_status.dart';

class OrderPostApiModel {
  OrderPostApiModel(
      {
      required this.customerId,
      required this.orderDate,
      required this.deliveryDate,
      required this.status,
      required this.orderItems});

  final String customerId;
  final DateTime orderDate;
  final DateTime deliveryDate;
  final OrderStatus status;
  final List<OrderItemApiModel> orderItems;

  factory OrderPostApiModel.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'customerId': String customerId,
        'orderDate': DateTime orderDate,
        'deliveryDate': DateTime deliveryDate,
        'status': OrderStatus status,
        'orderItems': List<Map<String, dynamic>> orderItems
      } =>
        OrderPostApiModel(
            customerId: customerId,
            orderDate: orderDate,
            deliveryDate: deliveryDate,
            status: status,
            orderItems: orderItems.map((o) => OrderItemApiModel.fromJson(o)).toList()),
      _ => throw const FormatException('Failed to load order.'),
    };
  }
}
