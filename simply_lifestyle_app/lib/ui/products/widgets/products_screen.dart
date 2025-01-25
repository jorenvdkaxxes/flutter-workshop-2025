import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:simply_lifestyle_app/routing/routes.dart';
import 'package:simply_lifestyle_app/ui/core/ui/error_indicator.dart';
import 'package:simply_lifestyle_app/ui/products/view_model/products_view_model.dart';

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
                  label: "Could not get the products, retry...",
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
                    onTap: () => context.go(
                        Routes.productsWithId(viewModel.products[index].id)),
                  );
                },
              );
            }));
  }
}
