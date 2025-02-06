import 'package:simply_lifestyle_app/domain/models/entity.dart';

class OrderItem extends Entity {
  OrderItem(
      {required super.id, required this.productId, required this.quantity});

  final String productId;
  final int quantity;

  factory OrderItem.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'id': String id,
        'productId': String productId,
        'quantity': int quantity
      } =>
        OrderItem(id: id, productId: productId, quantity: quantity),
      _ => throw const FormatException('Failed to load order item.'),
    };
  }
}
