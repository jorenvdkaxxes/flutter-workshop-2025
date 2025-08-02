import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/ui/auth/logout/widgets/logout_button.dart';

class AppScaffold extends StatelessWidget {
  const AppScaffold(
      {super.key,
      required this.title,
      required this.child,
      required this.selectedIndex,
      required this.onItemTapped,
      this.floatingActionButton});

  final String title;
  final Widget child;
  final int selectedIndex;
  final void Function(int)? onItemTapped;
  final Widget? floatingActionButton;

  bool isSelected(String currentLocation, String route) =>
      currentLocation == route;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text(title),
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
      body: Center(child: child),
      floatingActionButton: floatingActionButton,
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: [
            DrawerHeader(
              decoration: BoxDecoration(
                color: Colors.greenAccent,
              ),
              child: Column(
                children: [
                  Text('Simply Lifestyle'),
                  LogoutButton(viewModel: context.read())
                ],
              ),
            ),
            ListTile(
              title: const Text('Products'),
              selected: selectedIndex == 0,
              onTap: () {
                Navigator.of(context).pop();
                onItemTapped!(0);
              },
            ),
            ListTile(
              title: const Text('Orders'),
              selected: selectedIndex == 1,
              onTap: () {
                onItemTapped!(1);
                Navigator.of(context).pop();
              },
            ),
          ],
        ),
      ),
    );
  }
}
