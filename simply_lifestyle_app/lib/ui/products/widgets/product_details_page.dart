import 'package:flutter/material.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/ui/products/widgets/product_details_row.dart';

class ProductDetailsPage extends StatelessWidget {
  const ProductDetailsPage({super.key});

  List<Widget> getProductDetailsRows(Product product) {
    var productType = ProductDetailsRow(
        propertyName: 'Product type', propertyValue: product.productType.name);
    var description = ProductDetailsRow(
        propertyName: 'Description', propertyValue: product.description);
    var price = ProductDetailsRow(
        propertyName: 'Price', propertyValue: product.price.amount);
    var stock =
        ProductDetailsRow(propertyName: 'Stock', propertyValue: product.stock);
    return [productType, description, price, stock];
  }

  @override
  Widget build(BuildContext context) {
    final product = ModalRoute.of(context)!.settings.arguments as Product;

    return Scaffold(
        appBar: AppBar(
          title: Text(product.name),
        ),
        body: Padding(
            padding: EdgeInsets.only(left: 8),
            child: Column(children: getProductDetailsRows(product))));
  }
}
