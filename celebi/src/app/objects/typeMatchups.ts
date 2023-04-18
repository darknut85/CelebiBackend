export class TypeMatchup{
    grass: number[] = [0.5,2,2,2,0.5,2,0.5,0.5,1,1,1,1,1,2,1];
    bug: number[] = [0.5,1,2,2,1,1,1,0.5,2,0.5,1,1,1,2,1];
    poison: number[] = [0.5,2,0.5,1,1,1,1,2,1,0.5,2,1,1,1,1];
    fire: number[] = [0.5,0.5,1,0.5,2,1,1,2,2,1,1,1,1,1,1];
    water: number[] = [2,1,1,0.5,0.5,0.5,2,1,1,1,1,1,1,1,1];
    ice: number[] = [1,1,1,2,1,0.5,1,1,2,2,1,1,1,1,1];
    electric: number[] = [1,1,1,1,1,1,0.5,2,1,1,1,1,1,0.5,1];
    ground: number[] = [2,1,0.5,1,1,2,0,1,0.5,1,1,1,1,1,1];
    rock: number[] = [2,1,0.5,0.5,2,1,1,2,1,2,1,1,0.5,0.5,1];
    fighting: number[] = [1,0.5,1,1,1,1,1,1,0.5,1,2,1,1,2,1];
    psychic: number[] = [1,2,1,1,1,1,1,1,1,0.5,0.5,0,1,1,1];
    ghost: number[] = [1,0.5,0.5,1,1,1,1,1,1,0,1,2,0,1,1];
    normal: number[] = [1,1,1,1,1,1,1,1,2,1,1,0,1,1,1];
    flying: number[] = [0.5,0.5,1,1,1,2,2,0,2,0.5,1,1,1,1,1];
    dragon: number[] = [0.5,1,1,0.5,0.5,2,0.5,1,1,1,1,1,1,1,2];

    types: number[][] = [
        this.grass,this.bug,this.poison,
        this.fire,this.water,this.ice,
        this.electric,this.rock,this.ground,
        this.fighting, this.psychic, this.ghost,
        this.normal, this.flying, this.dragon
    ]

    typeNames: string[] = [
        "Grass","Bug","Poison",
        "Fire","Water","Ice",
        "Electric","Ground","Rock",
        "Fighting","Psychic","Ghost",
        "Normal","Flying","Dragon"
    ]
}