class Price{
  final double amount;
  final String currency;

  const Price({
    required this.amount,
    required this.currency,
  });

  factory Price.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'amount': double amount,
        'currency': String currency,
      } =>
        Price(
          amount: amount,
          currency: currency
        ),
      _ => throw const FormatException('Failed to load price.'),
    };
  }
}