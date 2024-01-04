import { api } from "$lib/services/api";

/** @type {import('./$types').PageLoad} */ export async function load({fetch}) {
  const types: string[] = await api.get('Prediction/Types', fetch);

  const championships = await api.get('Championship', fetch);

  const players = await api.get('Player', fetch);

  const teams = await api.get('Team', fetch)
  return {
    types: types,
    championships: championships,
    players: players,
    teams: teams
  };
};

///** @type {import('./$types').Actions} */
//export const actions = {
//	predict: async (event) => {
//		return null;
//	}
//};

