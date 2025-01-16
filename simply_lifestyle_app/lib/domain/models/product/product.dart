import 'package:simply_lifestyle_app/domain/models/entity.dart';
import 'package:simply_lifestyle_app/domain/models/product/price.dart';
import 'package:simply_lifestyle_app/domain/models/product/product_type.dart';

class Product extends Entity {
  final String name;
  final String description;
  final ProductType productType;
  final Price price;
  final int stock;

  Product(
      {required super.id,
      required this.name,
      required this.description,
      required this.productType,
      required this.price,
      required this.stock});

  factory Product.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'id': String id,
        'name': String name,
        'description': String description,
        'productType': int productType,
        'price': Map<String, dynamic> priceJson,
        'stock': int stock
      } =>
        Product(
            id: id,
            name: name,
            description: description,
            productType: ProductType.values[productType],
            price: Price.fromJson(priceJson),
            stock: stock),
      _ => throw const FormatException('Failed to load product.'),
    };
  }
}
