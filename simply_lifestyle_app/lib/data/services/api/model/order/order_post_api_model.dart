import 'package:simply_lifestyle_app/data/services/api/model/order/order_item_api_model.dart';
import 'package:simply_lifestyle_app/domain/models/order/order_status.dart';

class OrderPostApiModel {
  OrderPostApiModel(
      {required this.customerFirstName,
      required this.customerLastName,
      required this.deliveryDate,
      required this.status,
      required this.orderItems});

  final String customerFirstName;
  final String customerLastName;
  final DateTime deliveryDate;
  final OrderStatus status;
  final List<OrderItemApiModel> orderItems;

  factory OrderPostApiModel.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'customerFirstName': String customerFirstName,
        'customerLastName': String customerLastName,
        'deliveryDate': DateTime deliveryDate,
        'status': OrderStatus status,
        'orderItems': List<Map<String, dynamic>> orderItems
      } =>
        OrderPostApiModel(
            customerFirstName: customerFirstName,
            customerLastName: customerLastName,
            deliveryDate: deliveryDate,
            status: status,
            orderItems:
                orderItems.map((o) => OrderItemApiModel.fromJson(o)).toList()),
      _ => throw const FormatException('Failed to load order.'),
    };
  }

  Map<String, dynamic> toJson() {
    return {
      'customerFirstName': customerFirstName,
      'customerLastName': customerLastName,
      'deliveryDate': deliveryDate.toIso8601String(),
      'status': status.index,
      'orderItems': [...orderItems.map((o) => o.toJson())]
    };
  }
}
