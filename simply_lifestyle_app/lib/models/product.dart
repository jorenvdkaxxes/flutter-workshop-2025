class Product {
  final String name;
  final String description;

  const Product({
    required this.name,
    required this.description,
  });

  factory Product.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'name': String name,
        'description': String description,
      } =>
        Product(
          name: name,
          description: description
        ),
      _ => throw const FormatException('Failed to load product.'),
    };
  }
}