import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  {
    path: "identity",
    loadChildren: () =>
      import("./identity/identity.module").then((m) => m.IdentityModule),
  },
  {
    path: "expense",
    loadChildren: () =>
      import("./expense/expense.module").then((m) => m.ExpenseModule),
  },
  { path: 'category', loadChildren: () => import('./category/category.module').then(m => m.CategoryModule) },
  { path: '', pathMatch: 'full', redirectTo: 'identity' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
