// Copyright 2024 The Flutter team. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

import '../../../../utils/image_error_listener.dart';

class TiltedCards extends StatelessWidget {
  const TiltedCards({super.key});

  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
      constraints: const BoxConstraints(maxWidth: 300),
      child: const AspectRatio(
        aspectRatio: 1,
        child: Stack(
          alignment: Alignment.center,
          children: [
            Positioned(
              left: 0,
              child: _Card(
                imageUrl: 'https://simply-lifestyle.be/wp-content/uploads/2025/01/WhatsApp-Image-2025-01-29-at-14.58.07-5.jpeg',
                width: 200,
                height: 273,
                tilt: -3.83 / 360,
              ),
            ),
            Positioned(
              right: 0,
              child: _Card(
                imageUrl: 'https://www.stockverkoopadressen.com/listing_fotos/large_4add3fe103b5.jpg',
                width: 180,
                height: 230,
                tilt: 3.46 / 360,
              ),
            ),
            _Card(
              imageUrl: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJIY9QHFTBJ-zNgANFZi35t18J673GVQ2LvA&s',
              width: 225,
              height: 322,
              tilt: 0,
              showTitle: true,
            ),
          ],
        ),
      ),
    );
  }
}

class _Card extends StatelessWidget {
  const _Card({
    required this.imageUrl,
    required this.width,
    required this.height,
    required this.tilt,
    this.showTitle = false,
  });

  final double tilt;
  final double width;
  final double height;
  final String imageUrl;
  final bool showTitle;

  @override
  Widget build(BuildContext context) {
    return RotationTransition(
      turns: AlwaysStoppedAnimation(tilt),
      child: SizedBox(
        width: width,
        height: height,
        child: ClipRRect(
          borderRadius: BorderRadius.circular(20),
          child: Stack(
            fit: StackFit.expand,
            alignment: Alignment.center,
            children: [
              CachedNetworkImage(
                imageUrl: imageUrl,
                fit: BoxFit.cover,
                color: showTitle ? Colors.black.withValues(alpha: 0.5) : null,
                colorBlendMode: showTitle ? BlendMode.darken : null,
                errorListener: imageErrorListener,
              ),
              if (showTitle)
                Center(
                    child: SizedBox(
                  width: 100,
                  height: 100,
                  child: SvgPicture.asset('assets/logo.svg'),
                )),
            ],
          ),
        ),
      ),
    );
  }
}
