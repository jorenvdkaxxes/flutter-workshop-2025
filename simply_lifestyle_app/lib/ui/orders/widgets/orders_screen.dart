import 'package:flutter/material.dart';
import 'package:simply_lifestyle_app/ui/core/ui/error_indicator.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/orders_view_model.dart';

class OrdersScreen extends StatelessWidget {
  const OrdersScreen({super.key, required this.viewModel});

  final OrdersViewModel viewModel;

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
                  label: "Could not get the orders.",
                  onPressed: viewModel.load.execute,
                );
              }
              return ListView.builder(
                itemCount: viewModel.orders.length,
                prototypeItem: ListTile(
                  title: Text(viewModel.orders.first.id),
                ),
                itemBuilder: (context, index) {
                  return ListTile(
                    title: Text(viewModel.orders[index].id),
                    subtitle: Text('Status: ${viewModel.orders[index].orderStatus}'),
                    onTap: () {
                      // Navigator.push(
                      //   context,
                      //   MaterialPageRoute(
                      //     builder: (context) => const ProductDetailsPage(),
                      //     settings: RouteSettings(
                      //       arguments: viewModel.orders[index],
                      //     ),
                      //   ),
                      // );
                    },
                  );
                },
              );
            }));
  }
}
