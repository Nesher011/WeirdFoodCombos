import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { RecipeService} from 'src/app/services/recipe.service';
//import { RecipeFormDialogComponent } from './recipe-form-dialog/recipe-form-dialog.component';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css'],
})
export class RecipeComponent {
  recipes$ = this.recipeService.reports$;
  displayedColumns: string[] = [
    'name',
    'difficulty',
  ];

  constructor(
    private recipeService: RecipeService,
    private dialog: MatDialog
  ) {
    this.recipeService.getRecipes();
  }
}
