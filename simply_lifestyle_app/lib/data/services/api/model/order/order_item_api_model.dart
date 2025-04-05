class OrderItemApiModel {
  OrderItemApiModel({required this.productId, required this.quantity});

  final String productId;
  final int quantity;

  factory OrderItemApiModel.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'productId': String productId,
        'quantity': int quantity
      } =>
        OrderItemApiModel(productId: productId, quantity: quantity),
      _ => throw const FormatException('Failed to load order item.'),
    };
  }

  Map<String, dynamic> toJson() {
    return {'productId': productId, 'quantity': quantity};
  }
}
