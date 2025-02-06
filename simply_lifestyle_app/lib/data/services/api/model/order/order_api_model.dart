import 'package:simply_lifestyle_app/data/services/api/model/order/order_item_api_model.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_item.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_status.dart';

class OrderApiModel {
  OrderApiModel(
      {required this.id,
      required this.customerId,
      required this.orderDate,
      required this.orderStatus,
      required this.orderItems});

  final String id;
  final String customerId;
  final DateTime orderDate;
  final OrderStatus orderStatus;
  final List<OrderItemApiModel> orderItems;

  factory OrderApiModel.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'id': String id,
        'customerId': String customerId,
        'orderDate': DateTime orderDate,
        'orderStatus': OrderStatus orderStatus,
        'orderItems': List<Map<String, dynamic>> orderItems
      } =>
        OrderApiModel(
            id: id,
            customerId: customerId,
            orderDate: orderDate,
            orderStatus: orderStatus,
            orderItems: orderItems.map((o) => OrderItemApiModel.fromJson(o)).toList()),
      _ => throw const FormatException('Failed to load order.'),
    };
  }
}
