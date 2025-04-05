class OrderCreatedApiModel {
  OrderCreatedApiModel(
      {
      this.orderId});

  final String? orderId;

  factory OrderCreatedApiModel.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'orderId': String orderId
      } =>
        OrderCreatedApiModel(
            orderId: orderId),
      _ => throw const FormatException('Failed to load order.'),
    };
  }
}
