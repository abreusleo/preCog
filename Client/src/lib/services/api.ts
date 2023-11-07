async function get(
  route: string,
  fetch: (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>
) {

  try {
    const response = await fetch(`http://localhost:4001/${route}`, {
    headers: {
      "Origin": "http://localhost:5173"
    }
  });

  return await response.json();
  } catch (e) {
    console.log(e);
    return [];
  }
}

async function post(
  route: string,
  fetch: (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>
) {
  const response = await fetch(`http://localhost:4001/${route}`, {
    method: 'POST',
    headers: {
      "Origin": 'http://localhost:5173'
    }
  });

  return await response.json();
}

export const api = {
  get,
  post
};
