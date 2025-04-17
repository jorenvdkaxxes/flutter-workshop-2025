import 'package:flutter/material.dart';
import 'package:flutter_localizations/flutter_localizations.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/routing/router.dart';
import 'package:simply_lifestyle_app/ui/core/localization/applocalization.dart';
import 'package:simply_lifestyle_app/ui/core/ui/app_scaffold.dart';
import 'package:simply_lifestyle_app/ui/core/ui/base_screen.dart';

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

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  int selectedIndex = 0;

  final List<String> titles = ['Products', 'Orders'];

  late List<BaseScreen> widgetOptions;

  @override
  void initState() {
    super.initState();
    widgetOptions = <BaseScreen>[ProductsScreen(), OrdersScreen()];
  }

  void onItemTapped(int index) {
    setState(() {
      selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return AppScaffold(
        title: titles[selectedIndex],
        selectedIndex: selectedIndex,
        onItemTapped: onItemTapped,
        floatingActionButton:
            widgetOptions[selectedIndex].getFloatingActionButton(context),
        child: widgetOptions[selectedIndex]);
  }
}
