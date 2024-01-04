async function get(
  route: string,
  fetch: (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>
) {
  try {
    const response = await fetch(`http://nginx:80/api/${route}`, {
      method: 'GET'
    });
    return await response.json();
  } catch (e) {
    console.log(e);
    return [];
  }
}

async function post(
  route: string,
  body: BodyInit,
  params: string,
  fetch: (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>
) {
  try {
    const response = await fetch(`http://nginx:80/api/${route}${params}`, {
      method: 'POST',
      body: body
    });
    return await response.json();
  } catch (e) {
    console.log(e);
    return [];
  }
}

export const api = {
  get,
  post
};
