class LoginResponse {
  LoginResponse({
    required this.token,
    required this.userId,
  });

  final String token;
  final String userId;

  factory LoginResponse.fromJson(Map<String, Object?> json) {
    return switch (json) {
      {
        'token': String token,
        'userId': String userId,
      } =>
        LoginResponse(token: token, userId: userId),
      _ => throw const FormatException('Failed to load login response.'),
    };
  }
}
