import { Metadata, build, Validators, BaseEntity, Collection, CurrentUser as BaseCurrentUser, OrderedItem, Permutation, TypeConstructor } from '@caiu/library';

export { BaseEntity } from '@caiu/library';

export class Login {
  email = '';
  password = '';

  get metadata(): Metadata {
    return build(Metadata, {
      email: {
        validators: [Validators.required, Validators.email]
      }
    });
  }
}

export class Ordering<T> {
  private _history: Permutation<T>[] = [];

  constructor(private _items: T[], public ctor: TypeConstructor<T>, public orderKey = 'order', public idKey = 'examTypeId') {}

  get count(): number {
    return this.items.length;
  }

  get history(): Permutation<T>[] {
    return this._history;
  }

  get instance(): T {
    return new this.ctor();
  }

  get items(): T[] {
    return this._items.sort((a, b) => this.getItemOrder(a) - this.getItemOrder(b));
  }

  get maxIndex(): number {
    return this.count === 0 ? 0 : Math.max(...this.order.map(x => x.order));
  }

  get order(): OrderedItem<T>[] {
    return this.permutation.ranks;
  }

  get permutation(): Permutation<T> {
    return new Permutation<T>(
      this.items.map(
        item =>
          ({
            id: this.getItemId(item),
            order: this.getItemOrder(item)
          } as OrderedItem<T>)
      )
    );
  }

  get nextPosition(): number {
    return this.maxIndex + 1;
  }

  addItem(item: T): T[] {
    return this.addItemAtPosition(item, this.nextPosition);
  }

  addItemAtPosition(item: T, pos: number): T[] {
    const newItemId = this.getItemId(item);
    return [...this.items, build(this.ctor, item, { order: pos })].map(x => {
      const order = this.getItemOrder(x);
      const id = this.getItemId(x);
      return order <= pos || id === newItemId ? x : build(this.ctor, x, { order: order + 1 });
    });
  }

  archive(items?: T[]) {
    const permutation = items ? this.getPermutation(items) : this.permutation;
    this._history = [...this._history, permutation];
  }

  getItemId(item: T): any {
    return item[this.idKey];
  }

  getItemOrder(item: T): number {
    return item[this.orderKey];
  }

  getPermutation(items: T[]): Permutation<T> {
    return new Permutation(
      items.map(
        item =>
          ({
            id: this.getItemId(item),
            order: this.getItemOrder(item)
          } as OrderedItem<T>)
      )
    );
  }

  move(item: T, to: number): T[] {
    const from = this.getItemOrder(item);
    const itemId = this.getItemId(item);
    if (to === from) {
      return [...this.items];
    } else if (to < from) {
      return this.items.map(x => {
        const order = this.getItemOrder(x);
        const id = this.getItemId(x);
        return id === itemId ? build(this.ctor, x, { order: to }) : order < to || order > from ? x : build(this.ctor, x, { order: order + 1 });
      });
    } else {
      // to > from
      return this.items.map(x => {
        const order = this.getItemOrder(x);
        const id = this.getItemId(x);
        return id === itemId ? build(this.ctor, x, { order: to }) : order < from || order > to ? x : build(this.ctor, x, { order: order - 1 });
      });
    }
  }

  moveDown(item: T): T[] {
    return this.move(item, this.getItemOrder(item) + 1);
  }

  moveUp(item: T): T[] {
    return this.move(item, this.getItemOrder(item) - 1);
  }

  removeItem(item: T): T[] {
    return this.removeItemAtPosition(this.getItemOrder(item));
  }

  removeItemAtPosition(pos: number): T[] {
    return this.items
      .filter(item => this.getItemOrder(item) !== pos)
      .map(x => {
        const order = this.getItemOrder(x);
        return order < pos ? x : build(this.ctor, x, { order: order - 1 });
      });
  }

  updateItems(items: T[]): void {
    this.archive();
    this._items = items;
  }
}

export class Tab extends BaseEntity {
  label = '';
  routerLink = '';
}

export class Tabs extends Collection<Tab> {
  constructor() {
    super(Tab);
  }
}

export class CurrentUser extends BaseCurrentUser {
  doctorTypeId = 0;
  isAdmin = false;
  rvuRate = 0;
  yearGoalDollarAmount = 0;
  static Build(data: any): CurrentUser {
    return build(CurrentUser, BaseCurrentUser.Build(data));
  }

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['id', 'expiresInDate', 'isAdmin', 'password', 'passwordResetCode', 'role', 'shiftTypeId', 'shiftType', 'token', 'year', 'yearTypeId']
    });
  }
}
