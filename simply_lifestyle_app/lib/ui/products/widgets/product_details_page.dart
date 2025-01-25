import 'package:flutter/material.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/ui/core/ui/error_indicator.dart';
import 'package:simply_lifestyle_app/ui/products/view_model/product_detail_view_model.dart';
import 'package:simply_lifestyle_app/ui/products/widgets/product_details_row.dart';

class ProductDetailsPage extends StatelessWidget {
  const ProductDetailsPage({super.key, required this.viewModel});

  final ProductDetailViewModel viewModel;

  List<Widget> getProductDetailsRows(Product product) {
    var productName = ProductDetailsRow(
        propertyName: 'Product name', propertyValue: product.name);
    var productType = ProductDetailsRow(
        propertyName: 'Product type', propertyValue: product.productType.name);
    var description = ProductDetailsRow(
        propertyName: 'Description', propertyValue: product.description);
    var price = ProductDetailsRow(
        propertyName: 'Price', propertyValue: product.price.amount);
    var stock =
        ProductDetailsRow(propertyName: 'Stock', propertyValue: product.stock);
    return [productName, productType, description, price, stock];
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
      appBar: AppBar(
        title: Text('Product details'),
      ),
      body: ListenableBuilder(
        listenable: viewModel,
        builder: (context, _) {
          if (viewModel.loadProduct.running) {
            return const Center(child: CircularProgressIndicator());
          }

          if (viewModel.loadProduct.error) {
            return Center(
                child: ErrorIndicator(
              title: "Something went wrong.",
              label: "Could not get the product, retry...",
              onPressed: () =>
                  viewModel.loadProduct.execute(viewModel.lastQueriedProductId),
            ));
          }
          return Padding(
              padding: EdgeInsets.only(left: 8),
              child:
                  Column(children: getProductDetailsRows(viewModel.product!)));
        },
      ),
    ));
  }
}
