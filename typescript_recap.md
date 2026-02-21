# TypeScript — Grands Principes Spécifiques

---

## 1. Typage statique & Inférence

TS ajoute un système de types au-dessus de JS. Le compilateur infère souvent le type sans que tu l'annotes.

```typescript
let x = 42;         // inféré : number
let y: string = ""; // annoté explicitement
```

Types primitifs : `string`, `number`, `boolean`, `null`, `undefined`, `bigint`, `symbol`

Type spécial pour "n'importe quoi mais forcé à vérifier" : `unknown`  
Type "j'abandonne le typage" (à éviter) : `any`

---

## 2. Interfaces & Types

```typescript
interface User {
    name: string;
    age?: number; // optionnel
}

type ID = string | number; // alias de type
```

**Différence interface vs type :**
- `interface` : extensible, merge automatique si redéclarée
- `type` : plus flexible, supporte les unions/intersections complexes

---

## 3. Union & Intersection

```typescript
// Union : A OU B
type Input = string | number;

// Intersection : A ET B
type Admin = User & { role: string };
```

---

## 4. Type Guards

Permet de narrower un type dans un bloc conditionnel.

```typescript
function isString(val: unknown): val is string {
    return typeof val === 'string';
}

function process(input: unknown) {
    if (isString(input)) {
        console.log(input.toUpperCase()); // TS sait que c'est un string ici
    }
}
```

Utile quand `typeof` ne suffit pas (distinguer deux interfaces custom).

---

## 5. Generics

Permet d'écrire du code réutilisable avec des types variables.

```typescript
function merge<T, U>(a: T, b: U): T & U {
    return { ...a, ...b } as T & U;
}

class Stack<T> {
    private _elems: T[] = [];
    push(e: T) { this._elems.push(e); }
    pop(): T | undefined { return this._elems.pop(); }
}
```

**Contrainte de generic :**
```typescript
function getLength<T extends { length: number }>(val: T): number {
    return val.length;
}
```

---

## 6. Utility Types

Types built-in fournis par TS pour transformer des types existants.

```typescript
type User = { name: string; age: number; email: string };

Partial<User>        // toutes les props optionnelles
Required<User>       // toutes les props obligatoires
Readonly<User>       // toutes les props en lecture seule
Pick<User, "name">   // garde seulement "name"
Omit<User, "email">  // enlève "email"
Record<string, User> // dictionnaire string → User
```

---

## 7. Enums

```typescript
enum Direction {
    Up,    // 0
    Down,  // 1
    Left,  // 2
    Right  // 3
}

enum Status {
    Active = "ACTIVE",
    Inactive = "INACTIVE"
}
```

> Préférer les `const enum` pour éviter le code JS généré inutile, ou simplement des `union types` : `type Direction = "up" | "down" | "left" | "right"`

---

## 8. Tuple

Tableau avec un nombre et des types fixes par position.

```typescript
type Point = [number, number];
const p: Point = [10, 20];

type Named = [string, number, boolean];
```

---

## 9. Décorateurs

Annotations qui wrappent classes, méthodes ou champs. Standard ES (TS 5+, sans `experimentalDecorators`).

**Décorateur de classe :**
```typescript
function Singleton<T extends { new(...args: any[]): {} }>(target: T) {
    let instance: T;
    return class extends target {
        constructor(...args: any[]) {
            if (instance) return instance;
            super(...args);
            instance = this as any;
        }
    };
}
```

**Décorateur de méthode :**
```typescript
function Log(originalMethod: any, context: ClassMethodDecoratorContext) {
    return function(this: any, ...args: any[]) {
        console.log(`Appel de ${context.name as string}`, args);
        const result = originalMethod.apply(this, args);
        console.log(`Retour :`, result);
        return result;
    };
}
```

**Décorateur de champ :**
```typescript
function Readonly(target: any, context: ClassFieldDecoratorContext) {
    return function(this: any, initialValue: any) {
        Object.defineProperty(this, context.name, {
            value: initialValue,
            writable: false,
            configurable: false
        });
        return initialValue;
    };
}
```

`context.name` → nom du membre  
`context.kind` → `"class"` | `"method"` | `"field"` | `"getter"` | `"setter"`

---

## 10. tsconfig essentiels

```json
{
  "compilerOptions": {
    "target": "ESNext",
    "module": "ESNext",
    "strict": true,              // active tous les checks stricts
    "moduleResolution": "Node",
    "esModuleInterop": true,
    "resolveJsonModule": true,   // import de .json
    "outDir": "./dist"
  }
}
```

`strict: true` active notamment :
- `strictNullChecks` : `null` et `undefined` ne sont pas assignables à n'importe quoi
- `noImplicitAny` : interdit le `any` implicite
- `strictFunctionTypes` : vérification stricte des signatures de fonctions

---

## 11. Narrowing

TS affine automatiquement le type selon le contexte.

```typescript
function print(val: string | number) {
    if (typeof val === "string") {
        // val est string ici
        console.log(val.toUpperCase());
    } else {
        // val est number ici
        console.log(val.toFixed(2));
    }
}
```

Fonctionne avec `typeof`, `instanceof`, `in`, guards custom (`val is Type`), et `switch`.

---

## 12. Mapped Types

Transformer toutes les propriétés d'un type dynamiquement.

```typescript
type Optional<T> = {
    [K in keyof T]?: T[K];
};

// Équivalent à Partial<T> built-in
```

---

## Cheat Sheet rapide

| Concept | Syntaxe |
|---|---|
| Type union | `string \| number` |
| Type intersection | `A & B` |
| Optionnel | `prop?: string` |
| Non-null assertion | `value!` |
| Cast | `value as string` |
| Typeof type | `typeof myVar` |
| Keyof | `keyof MyType` |
| Generic contraint | `T extends X` |
