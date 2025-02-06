import 'package:flutter/material.dart';
import 'package:logging/logging.dart';
import 'package:simply_lifestyle_app/ui/core/ui/error_indicator.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/new_order_view_model.dart';
import 'package:simply_lifestyle_app/ui/orders/widgets/new_order/new_order_form.dart';

class NewOrderScreen extends StatelessWidget {
  const NewOrderScreen({super.key, required this.viewModel});

  final NewOrderViewModel viewModel;

  void createOrder(Map<String, dynamic> values) {
    Logger('Test').fine(values.entries.first.value);
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
            appBar: AppBar(
              title: Text('New order'),
            ),
            body: ListenableBuilder(
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

                  return NewOrderForm(
                    products: viewModel.products,
                    createOrder: createOrder,
                  );
                })));
  }
}
