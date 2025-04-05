import 'package:simply_lifestyle_app/domain/models/entity.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_item.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_status.dart';

class Order extends Entity {
  Order(
      {super.id,
      this.customerId,
      this.customerFirstName,
      this.customerLastName,
      required this.orderDate,
      required this.deliveryDate,
      required this.status,
      required this.orderItems});

  final String? customerId;
  final String? customerFirstName;
  final String? customerLastName;
  final DateTime orderDate;
  final DateTime deliveryDate;
  final OrderStatus status;
  final List<OrderItem> orderItems;

  factory Order.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'id': String id,
        'customerId': String customerId,
        'customerFirstName': String customerFirstName,
        'customerLastName': String customerLastName,
        'orderDate': DateTime orderDate,
        'deliveryDate': DateTime deliveryDate,
        'status': OrderStatus status,
        'orderItems': List<Map<String, dynamic>> orderItems
      } =>
        Order(
            id: id,
            customerId: customerId,
            customerFirstName: customerFirstName,
            customerLastName: customerLastName,
            orderDate: orderDate,
            deliveryDate: deliveryDate,
            status: status,
            orderItems: orderItems.map((o) => OrderItem.fromJson(o)).toList()),
      _ => throw const FormatException('Failed to load order.'),
    };
  }
}
