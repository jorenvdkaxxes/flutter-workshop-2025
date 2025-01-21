import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/orders_view_model.dart';

import 'main_staging.dart' as staging;
import 'package:simply_lifestyle_app/ui/orders/widgets/orders_screen.dart';
import 'package:simply_lifestyle_app/ui/products/view_model/products_view_model.dart';
import 'package:simply_lifestyle_app/ui/products/widgets/products_screen.dart';

void main() {
  staging.main();
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Simply Lifestyle App',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.green),
        useMaterial3: true,
      ),
      home: const MyHomePage(),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key});

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  int _selectedIndex = 0;

  final List<String> titles = ['Products', 'Orders'];

  late List<Widget> _widgetOptions;

  @override
  void initState() {
    super.initState();
    final productsViewModel = ProductsViewModel(productsRepository: context.read());
    final ordersViewModel = OrdersViewModel(ordersRepository: context.read());
    _widgetOptions = <Widget>[
      ProductsScreen(viewModel: productsViewModel),
      OrdersScreen(viewModel: ordersViewModel)
    ];
  }

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  Widget? _getWidget() {
    if (_selectedIndex != 1) return null;

    return FloatingActionButton(
      onPressed: () => {},
      tooltip: 'Add',
      child: const Icon(Icons.add),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text(titles[_selectedIndex]),
        leading: Builder(
          builder: (context) {
            return IconButton(
              icon: const Icon(Icons.menu),
              onPressed: () {
                Scaffold.of(context).openDrawer();
              },
            );
          },
        ),
      ),
      body: Center(
        child: _widgetOptions[_selectedIndex],
      ),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: [
            const DrawerHeader(
              decoration: BoxDecoration(
                color: Colors.greenAccent,
              ),
              child: Text('Simply Lifestyle'),
            ),
            ListTile(
              title: const Text('Products'),
              selected: _selectedIndex == 0,
              onTap: () {
                Navigator.pop(context);
                _onItemTapped(0);
              },
            ),
            ListTile(
              title: const Text('Orders'),
              selected: _selectedIndex == 1,
              onTap: () {
                Navigator.pop(context);
                _onItemTapped(1);
              },
            ),
          ],
        ),
      ),
      floatingActionButton: _getWidget(),
    );
  }
}
