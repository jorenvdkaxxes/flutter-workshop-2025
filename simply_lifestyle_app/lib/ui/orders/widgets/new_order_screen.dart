import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:simply_lifestyle_app/routing/routes.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/new_order_view_model.dart';

class NewOrderScreen extends StatelessWidget {
  const NewOrderScreen({super.key, required this.viewModel});

  final NewOrderViewModel viewModel;

  @override
  Widget build(BuildContext context) {
    return PopScope(
        canPop: false,
        onPopInvokedWithResult: (didPop, r) {
          if (!didPop) context.go(Routes.home);
        },
        child: Scaffold(
            appBar: AppBar(
              title: Text('New order'),
            ),
            body: Padding(
              padding: EdgeInsets.only(left: 8),
              child: Text('Body'),
            )));
  }
}
