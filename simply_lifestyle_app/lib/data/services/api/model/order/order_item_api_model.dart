class OrderItemApiModel {
  OrderItemApiModel({this.id, required this.productId, required this.quantity});

  final String? id;
  final String productId;
  final int quantity;

  factory OrderItemApiModel.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'id': String id,
        'productId': String productId,
        'quantity': int quantity
      } =>
        OrderItemApiModel(id: id, productId: productId, quantity: quantity),
      _ => throw const FormatException('Failed to load order item.'),
    };
  }

  Map<String, dynamic> toJson() {
    return {'id': id, 'productId': productId, 'quantity': quantity};
  }
}
