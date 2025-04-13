import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/ui/core/ui/error_indicator.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/new_order_view_model.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/orders_view_model.dart';
import 'package:simply_lifestyle_app/ui/orders/widgets/new_order/new_order_form.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class NewOrderScreen extends StatelessWidget {
  const NewOrderScreen({super.key, required this.viewModel});

  final NewOrderViewModel viewModel;

  void createOrder(BuildContext context, Map<String, dynamic> values) async {
    showSnackbar(context, 'Processing data');

    var result = await viewModel.createOrder(values);

    if (result is Ok && context.mounted) {
      showSnackbar(context, 'Successfully created the order');
      context.read<OrdersViewModel>().load.execute();
      context.pop();
    } else if (result is Error && context.mounted) {
      showSnackbar(context, 'Something went wrong');
    }
  }

  void showSnackbar(BuildContext context, String text) {
    ScaffoldMessenger.of(context).hideCurrentSnackBar();
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(content: Text(text)),
    );
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
                    createOrder: (values) => createOrder(context, values),
                  );
                })));
  }
}
