``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1466 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]       : .NET Framework 4.8 (4.8.4420.0), X86 LegacyJIT
  LegacyJitX64 : .NET Framework 4.8 (4.8.4420.0), X64 LegacyJIT
  LegacyJitX86 : .NET Framework 4.8 (4.8.4420.0), X86 LegacyJIT
  RyuJitX64    : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT


```
|     Method |          Job |       Jit | Platform |    Mean |   Error |  StdDev |        Gen 0 |       Gen 1 |      Gen 2 | Allocated |
|----------- |------------- |---------- |--------- |--------:|--------:|--------:|-------------:|------------:|-----------:|----------:|
| Livel4Bech | LegacyJitX64 | LegacyJit |      X64 | 46.98 s | 0.778 s | 0.690 s | 1880000.0000 | 691000.0000 | 12000.0000 |     11 GB |
| Livel4Bech | LegacyJitX86 | LegacyJit |      X86 | 46.28 s | 0.430 s | 0.402 s | 1150000.0000 | 608000.0000 |  8000.0000 |      6 GB |
| Livel4Bech |    RyuJitX64 |    RyuJit |      X64 | 44.94 s | 0.894 s | 0.792 s | 1881000.0000 | 692000.0000 | 12000.0000 |     11 GB |
