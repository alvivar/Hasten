# Gigas

Entity Component System (ECS) for Unity that works on classic MonoBehaviour
tech.

## Motivation

The official Unity ECS (DOTS) is pretty cool and stuff, I tried it and I really
like what they are creating. But you can't use it yet, and with some luck maybe
we may need to wait until Unity 2021 LTS for a production-ready well tested
version that works completely with everything, who knows.

But we really want to start thinking with Data Oriented patterns for our code
and make it easy to eventually migrate to DOTS.

## Goal

- It should be easy to port logic and algorithms to DOTS. So, we'll avoid weird
  stuff.

- We want this library to be efficient, so, we'll continue looking deeply at the
  profiler and mutating the code to achieve more power and less garbage. Raise
  an issue if you have any tips or feedback of how we can do better.

## Created by

- [Josué Soto](https://www.linkedin.com/in/josue-soto-cambronero-3a8b1539/)
- [Andrés Villalobos](https://www.linkedin.com/in/alvivar/)
