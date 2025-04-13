import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/ui/core/ui/error_indicator.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/orders_view_model.dart';

class OrdersScreen extends StatelessWidget {
  const OrdersScreen({super.key});

  @override
  Widget build(BuildContext context) {
    OrdersViewModel viewModel = context.read();

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
                  label: "Could not get the orders, retry...",
                  onPressed: viewModel.load.execute,
                );
              }

              if (viewModel.orders.isEmpty) {
                return const Center(
                  child: Text("No orders found"),
                );
              }

              return ListView.builder(
                itemCount: viewModel.orders.length,
                prototypeItem: ListTile(
                  title: Text(viewModel.orders.first.id ?? ''),
                ),
                itemBuilder: (context, index) {
                  return ListTile(
                    title: Text(viewModel.orders[index].id ?? ''),
                    subtitle:
                        Text('Status: ${viewModel.orders[index].status}'),
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
