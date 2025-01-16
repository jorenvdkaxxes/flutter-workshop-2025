import 'package:flutter/material.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/orders_view_model.dart';

class OrdersScreen extends StatefulWidget {
  const OrdersScreen({super.key, required this.viewModel});

  final OrdersViewModel viewModel;

  @override
  State<OrdersScreen> createState() => _OrdersScreenState();
}

class _OrdersScreenState extends State<OrdersScreen> {
  final List<String> items = List<String>.generate(5, (i) => 'Order $i');

  late int index;

  @override
  void initState() {
    super.initState();
    index = items.length;
  }

  @override
  void dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      itemCount: items.length,
      prototypeItem: ListTile(
        title: Text(items.first),
      ),
      itemBuilder: (context, index) {
        return ListTile(
          title: Text(items[index]),
        );
      },
    );
  }
}
