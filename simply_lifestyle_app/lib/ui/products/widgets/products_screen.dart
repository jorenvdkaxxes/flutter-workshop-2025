import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/ui/core/ui/error_indicator.dart';
import 'package:simply_lifestyle_app/ui/products/view_model/products_view_model.dart';
import 'package:simply_lifestyle_app/ui/products/widgets/product_details_page.dart';

class ProductsScreen extends StatelessWidget {
  const ProductsScreen({super.key, required this.viewModel});

  final ProductsViewModel viewModel;

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: ListenableBuilder(
            listenable: viewModel,
            builder: (context, _) {
              if (viewModel.load.running) {
                return const Center(child: CircularProgressIndicator());
              }

              if (viewModel.load.error) {
                return ErrorIndicator(
                  title: "Something went wrong.",
                  label: "Could not get the products.",
                  onPressed: viewModel.load.execute,
                );
              }
              return ListView.builder(
                itemCount: viewModel.products.length,
                prototypeItem: ListTile(
                  title: Text(viewModel.products.first.name),
                ),
                itemBuilder: (context, index) {
                  return ListTile(
                    title: Text(viewModel.products[index].name),
                    subtitle: Text('Stock: ${viewModel.products[index].stock}'),
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => ProductDetailsPage(viewModel: context.read(),),
                          settings: RouteSettings(
                            arguments: viewModel.products[index],
                          ),
                        ),
                      );
                    },
                  );
                },
              );
            }));
  }
}