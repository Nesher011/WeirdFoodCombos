import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { API_PATHS } from 'src/environments/environment';
import { Recipe} from '../models/recipe';

const REPORTS_API_PATH = `${API_PATHS.base}${API_PATHS.recipes}`;

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  public reports$: BehaviorSubject<Recipe[]> = new BehaviorSubject<Recipe[]>(
    []
  );
  constructor(private client: HttpClient) { }

  public getRecipes() {
    return this.client
      .get<Recipe[]>(REPORTS_API_PATH)
      .subscribe((data: Recipe[]) => {
        this.reports$.next(data);
      });
  }

  public getRecipe(id: string | null) {
    return this.client.get<Recipe>(`${REPORTS_API_PATH}/${id}`);
  }

}
