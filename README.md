Simple ECS (pure C#)

No memory allocations.
No external dependencies.
No code generator.
No unsafe code.

O(1) - search for value.
O(1) - removing a value.
O(1) - setting the value.
O(1) - value checking.

Filters:

[include:0; include:N) - number of active components to include
[exclude:0; exclude:N) - number of active components to exclude

1. include:1 exclude:0 -> complexity O(inc0)
2. include:2 exclude:0 -> complexity O(min(inc0, inc1))
3. include:3 exclude:0 -> complexity O(min(inc0, inc1, inc2))
4. include:1 exclude:1 -> complexity O(inc0)
