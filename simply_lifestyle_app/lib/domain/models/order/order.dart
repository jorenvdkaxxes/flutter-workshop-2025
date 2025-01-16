import 'package:simply_lifestyle_app/domain/models/entity.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_item.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_status.dart';

class Order extends Entity {
  Order(
      {required super.id,
      required this.customerId,
      required this.orderDate,
      required this.orderStatus,
      required this.orderItems});

  final String customerId;
  final DateTime orderDate;
  final OrderStatus orderStatus;
  final List<OrderItem> orderItems;

  factory Order.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'id': String id,
        'customerId': String customerId,
        'orderDate': DateTime orderDate,
        'orderStatus': OrderStatus orderStatus,
        'orderItems': List<Map<String, dynamic>> orderItems
      } =>
        Order(
            id: id,
            customerId: customerId,
            orderDate: orderDate,
            orderStatus: orderStatus,
            orderItems: orderItems.map((o) => OrderItem.fromJson(o)).toList()),
      _ => throw const FormatException('Failed to load order.'),
    };
  }
}
