import 'package:flutter/material.dart';

abstract class BaseScreen extends StatelessWidget {
  const BaseScreen({super.key});

  Widget? getFloatingActionButton(BuildContext context);
}
