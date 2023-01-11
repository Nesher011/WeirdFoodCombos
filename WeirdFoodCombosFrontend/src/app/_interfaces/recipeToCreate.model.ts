export interface RecipeToCreate {
  name: string | undefined,
  difficulty: number | undefined,
  timeNeededInMinutes: number | undefined,
  servings: number | undefined,
  ownerId: string | undefined,
  createdDate: Date | undefined,
  imagePath: string | undefined
  //List<Ingredient>
  //List<Step>
}
