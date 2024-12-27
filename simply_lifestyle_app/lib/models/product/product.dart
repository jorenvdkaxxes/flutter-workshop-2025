import 'package:simply_lifestyle_app/models/product/price.dart';
import 'package:simply_lifestyle_app/models/product/product_type.dart';
import 'package:simply_lifestyle_app/models/product/weight.dart';

class Product {
  final String name;
  final String description;
  final ProductType productType;
  final Weight weight;
  final Price price;

  const Product({
    required this.name,
    required this.description,
    required this.productType,
    required this.weight,
    required this.price
  });

  factory Product.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'name': String name,
        'description': String description,
        'productType': int productType,
        'weight': Map<String, dynamic> weightJson,
        'price': Map<String, dynamic> priceJson
      } =>
        Product(
          name: name,
          description: description,
          productType: ProductType.values[productType],
          weight: Weight.fromJson(weightJson),
          price: Price.fromJson(priceJson)
        ),
      _ => throw const FormatException('Failed to load product.'),
    };
  }
}