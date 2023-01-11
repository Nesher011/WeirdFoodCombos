import { RecipeToCreate } from './_interfaces/recipeToCreate.model';
import { Recipe } from './_interfaces/recipe.model';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isCreate: boolean | undefined;
  name: string | undefined;
  address: string | undefined;
  difficulty: number | undefined;
  timeNeededInMinutes: number | undefined;
  servings: number | undefined;
  ownerId: string | undefined;
  createdDate: Date | undefined;
  imagePath: string | undefined;
  recipe: RecipeToCreate | undefined;
  recipes: Recipe[] = [];
  title = 'WeirdFoodCombosFrontend'

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.isCreate = true;
  }

  onCreate = () => {
    this.recipe = {
      name: this.name,
      difficulty: this.difficulty,
      timeNeededInMinutes: this.timeNeededInMinutes,
      servings: this.servings,
      ownerId: this.ownerId,
      createdDate: this.createdDate,
      imagePath: ''
    }

    this.http.post('https://localhost:7128/api/recipe', this.recipe)
      .subscribe({
        next: _ => {
          this.getRecipes();
          this.isCreate = false;
        },
        error: (err: HttpErrorResponse) => console.log(err)
      });
  }

  private getRecipes = () => {
    this.http.get('https://localhost:7128/api/recipe')
      .subscribe({
        next: (res) => this.recipes = res as Recipe[],
        error: (err: HttpErrorResponse) => console.log(err)
      });
  }

  returnToCreate = () => {
    this.isCreate = true;
    this.name = '';
    this.difficulty = 0;
    this.timeNeededInMinutes = 0;
    this.servings = 0;
    this.ownerId = '';
    this.createdDate = Date.prototype;
  }
}
