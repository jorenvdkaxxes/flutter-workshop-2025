class Weight{
  final double value;
  final String unit;

  const Weight({
    required this.value,
    required this.unit,
  });

  factory Weight.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'value': double value,
        'unit': String unit,
      } =>
        Weight(
          value: value,
          unit: unit
        ),
      _ => throw const FormatException('Failed to load weight.'),
    };
  }
}