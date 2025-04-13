import 'package:flutter/material.dart';
import 'package:flutter_localizations/flutter_localizations.dart';
import 'package:go_router/go_router.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/routing/router.dart';
import 'package:simply_lifestyle_app/routing/routes.dart';
import 'package:simply_lifestyle_app/ui/core/localization/applocalization.dart';

import 'main_staging.dart' as staging;
import 'package:simply_lifestyle_app/ui/orders/widgets/orders_screen.dart';
import 'package:simply_lifestyle_app/ui/products/widgets/products_screen.dart';

void main() {
  staging.main();
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      localizationsDelegates: [
        GlobalWidgetsLocalizations.delegate,
        GlobalMaterialLocalizations.delegate,
        AppLocalizationDelegate(),
      ],
      title: 'Simply Lifestyle App',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.green),
        useMaterial3: true,
      ),
      routerConfig: router(context.read()),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key});

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  final List<String> titles = ['Products', 'Orders'];


  @override
  void initState() {
    super.initState();
  }

  Widget? _getWidget() {
    return FloatingActionButton(
      onPressed: () => context.go(Routes.newOrder),
      tooltip: 'Add',
      child: const Icon(Icons.add),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text('Test'),
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
        child: ProductsScreen(),
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
              onTap: () {
                Navigator.pop(context);
                context.go(Routes.products);
              },
            ),
            ListTile(
              title: const Text('Orders'),
              onTap: () {
                Navigator.pop(context);
                context.go(Routes.orders);
              },
            ),
          ],
        ),
      ),
      floatingActionButton: _getWidget(),
    );
  }
}
