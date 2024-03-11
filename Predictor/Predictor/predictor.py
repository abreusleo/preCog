import grpc
from concurrent import futures
import predictor_server_pb2_grpc as pb2_grpc
import predictor_server_pb2 as pb2
from dotenv import load_dotenv
import os

load_dotenv('../../.env')

class PredictorService(pb2_grpc.PredictorGrpcServicer):

    def __init__(self, *args, **kwargs):
        pass

    def PlayerPrediction(self, request, context):
        print("Received a request! Prediction for the following players: %s VS %s" % (request.firstPlayer.nickname, request.secondPlayer.nickname))
        #Prediction
        result_prediction = request.firstPlayer
        result = {'player': result_prediction}

        return pb2.PlayerPredictionOutput(**result)

    def TeamPrediction(self, request, context):
        print("Received a request! Prediction for the following match: %s VS %s" % (request.firstTeamAcronym, request.secondTeamAcronym))
        #Prediction
        result_prediction = request.firstTeamAcronym
        result = {'name': result_prediction}

        return pb2.TeamPredictionOutput(**result)
    
    def ChampionshipPrediction(self, request, context):
        print("Received a request! Prediction for the following championship: %s" % request.name)
        #Prediction
        result_prediction = 1
        result = {'winnerName': result_prediction}
 
        return pb2.ChampionshipPredictionOutput(**result)

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    pb2_grpc.add_PredictorGrpcServicer_to_server(PredictorService(), server)
    PORT_ENV = os.environ['PREDICTOR_PORT']
    server.add_insecure_port('[::]:%s' % PORT_ENV)
    server.start()
    print("Server running!")
    server.wait_for_termination()

if __name__ == '__main__':
    serve()